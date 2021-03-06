function solve(input = []) {

    let result = new Set([...input]
        .sort((a, b) => a.length - b.length || a.localeCompare(b)))

    result.forEach(el => console.log(el));
};

solve([
    'Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
)

solve([
    'Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']
)

function getUsernames(input) {
    let usernames = new Set();

    for (let name of input) {
        usernames.add(name);
    }
    let sortedUsers = [...usernames].sort((a, b) => sortUsernames(a, b));
    console.log(sortedUsers.join("\n"));

    function sortUsernames(nameOne, nameTwo) {
        if (nameOne.length === nameTwo.length) {
            return nameOne.localeCompare(nameTwo);
        }
        return nameOne.length - nameTwo.length;
    }
}
getUsernames([
    'Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
)

getUsernames([
    'Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot']
)