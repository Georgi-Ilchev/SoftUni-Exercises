const { expect } = require('chai');
const { chromium, request } = require('playwright-chromium');

const mockData = {
    "messages": {
        "-LxHVtajG3N1sU714pVj": {
            "author": "Spami",
            "content": "Hello, are you there?"
        },
        "-LxIDxC-GotWtf4eHwV8": {
            "author": "Garry",
            "content": "Yep, whats up :?"
        },
        "-LxIDxPfhsNipDrOQ5g_": {
            "author": "Spami",
            "content": "How are you? Long time no see? :)"
        },
        "-LxIE-dM_msaz1O9MouM": {
            "author": "George",
            "content": "Hello, guys! :))"
        },
        "-LxLgX_nOIiuvbwmxt8w": {
            "author": "Spami",
            "content": "Hello, George nice to see you! :)))"
        }
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
    let browser, page;

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

    it('Should load posts when refresh button is clicked', async () => {
        await page.goto('http://localhost:5500');
        await page.route('**/jsonstore/messenger*', request => {
            request.fulfill(json(mockData.messages));
        });

        const [response] = await Promise.all([
            page.waitForResponse(r => r.request().url().includes('/jsonstore/messenger') &&
                r.request().method() === 'GET'),
            page.click('#refresh')
        ]);

        const data = await response.json();

        expect(data).to.deep.eq(mockData.messages);
    });

    it('Should send request', async () => {
        await page.goto('http://localhost:5500');
        await page.route('**/jsonstore/messenger*', request => {
            request.fulfill(json({ author: 'Gosho', content: 'Sending message' }));
        });

        await page.fill('#author', 'Gosho');
        await page.fill('#content', 'Sending message');

        const [response] = await Promise.all([
            page.waitForRequest(r => r.url().includes('/jsonstore/messenger') &&
                r.method() === 'POST'),
            page.click('#submit')
        ]);

        const data = JSON.parse(await response.postData());

        expect(data).to.deep.eq({ author: 'Gosho', content: 'Sending message' });
    });
})