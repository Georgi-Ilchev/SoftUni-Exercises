const { chromium } = require('playwright-chromium');
const { expect } = require('chai');


describe('E2E tests', async function () {
    //this.timeout(5000);
    let browser, page;

    before(async () => {
        // browser = await chromium.launch({ headless: false, slowMo: 500 });
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

    it('Initial load', async () => {
        await page.goto('http://localhost:5500');
        await page.waitForSelector('.accordion');
        const content = await page.textContent('#main');

        expect(content).to.contains('Scalable Vector Grephics');
        expect(content).to.contains('Open standard');
        expect(content).to.contains('Unix');
        expect(content).to.contains('ALGOL');
    });

    it('More button should work correctly', async () => {
        await page.goto('http://localhost:5500');
        await page.waitForSelector('.accordion');

        await page.click('text=More');

        await page.waitForResponse(/articles\/details/i);

        await page.waitForSelector('.accordion p');
        const visible = await page.isVisible('.accordion p');

        expect(visible).to.be.true;
    });

    it('Less button should work correctly', async () => {
        await page.goto('http://localhost:5500');
        await page.waitForSelector('.accordion');

        await page.click('text=More');
        await page.waitForResponse(/articles\/details/i);

        await page.waitForSelector('.accordion p', { state: 'visible' });
        await page.click('text=Less');
        const visible = await page.isVisible('.accordion p');

        expect(visible).to.be.false;
    });
});
