export default async function home() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    fetch('http://localhost:5000')
        .then(res => res.json())
        .then(data => console.log(data));

    this.partial('./templates/home.hbs', this.app.userData);
}