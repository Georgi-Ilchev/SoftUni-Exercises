const { chromium, request } = require('playwright-chromium');
const { expect } = require('chai');

const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
        "author": "J.K.Rowling",
        "title": "Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
        "author": "Svetlin Nakov", "title":
            "C# Fundamentals"
    }
};

function json(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}

describe('Tests', async function () {
    this.timeout(6000);

    let page, browser;

    before(async () => {
        browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    it('Should load and display all books', async () => {
        await page.route('**/jsonstore/collections/books*', (route) => {
            route.fulfill(json(mockData));
        });

        await page.goto('http://localhost:5500');

        await page.click('text=Load All Books');

        await page.waitForSelector('text=Harry Potter');

        const rows = await page.$$eval('tr', (rows) => rows.map(r => r.textContent.trim()));

        expect(rows[1]).to.contains('Harry Potter');
        expect(rows[1]).to.contains('Rowling');
        expect(rows[2]).to.contains('C# Fundamentals');
        expect(rows[2]).to.contains('Nakov');
    });

    it('Should can create book', async () => {
        await page.goto('http://localhost:5500');

        await page.fill('form#createForm >> input[name="title"]', 'Title');
        await page.fill('form#createForm >> input[name="author"]', 'Author');

        const [request] = await Promise.all([
            page.waitForRequest(request => request.method() == 'POST'),
            page.click('form#createForm >> text=Submit')
        ]);

        const data = JSON.parse(request.postData());
        expect(data.title).to.equal('Title');
        expect(data.author).to.equal('Author');
    });

    it('Should loads correct form in edit book', async () => {
        await page.goto('http://localhost:5500');
        await page.route('**/jsonstore/collections/books*', request =>
            request.fulfill(json(mockData)));
        await page.click('#loadBooks');
        await page.click('.editBtn:nth-child(1)');

        const editFormDisplay = await page.$eval('#editForm', el => el.style.display);
        const createFormDisplay = await page.$eval('#createForm', el => el.style.display);

        expect(editFormDisplay).to.eq('block');
        expect(createFormDisplay).to.eq('none');
    });

    it('Should loads correct information about edit', async () => {
        await page.goto('http://localhost:5500');
        await page.route('**/jsonstore/collections/books*', request => {
            request.fulfill(json(mockData));
        });

        await page.route('**/jsonstore/collections/books/*', request => {
            request.fulfill(json({ title: 'Title', author: 'Author' }));
        });

        await page.click('#loadBooks');
        await page.click('.editBtn:nth-child(1)');

        const [response] = await Promise.all([
            page.waitForResponse(r => r.request().url().includes('/jsonstore/collections/books/')),
            page.click('text="Save"')
        ]);
        const data = JSON.parse(await response.body());

        expect(data.title).to.eq('Title');
        expect(data.author).to.eq('Author');
    });

    it('Should send correct request', async () => {
        await page.goto('http://localhost:5500');
        await page.route('**/jsonstore/collections/books*', request => {
            request.fulfill(json(mockData));
        });
        await page.route('**/jsonstore/collections/books/*', request => {
            request.fulfill(json({ title: 'Title', author: 'Author' }));
        });

        await page.click('#loadBooks');
        await page.click('.editBtn:nth-child(1)');

        const [response] = await Promise.all([
            page.waitForResponse(r => r.request().url()
                .includes('/jsonstore/collections/books/') && r.request().method() === 'PUT'),
            page.click('text="Save"')
        ]);

        const data = JSON.parse(await response.body());

        expect(data).to.deep.eq({
            title: 'Title',
            author: 'Author'
        });
    });

    it(`testing delete functionality`, async () => {
        await page.goto('http://localhost:5500');
        await page.route('**/jsonstore/collections/books*', request => {
            request.fulfill(json(mockData));
        });
        await page.route('**/jsonstore/collections/books/*', request => {
            request.fulfill(json({ message: 'book deleted' }))
        });
        await page.click('#loadBooks');

        await page.once('dialog', async dialog => {
            await dialog.accept();
        });

        const [response] = await Promise.all([
            page.waitForResponse(r => r.request().url()
                .includes('/jsonstore/collections/books/') &&
                r.request().method() === 'DELETE'),
            page.click('.deleteBtn:nth-child(2)')
        ]);

        const data = JSON.parse(await response.body());
        expect(data).to.deep.eq({ message: 'book deleted' });
    })
});