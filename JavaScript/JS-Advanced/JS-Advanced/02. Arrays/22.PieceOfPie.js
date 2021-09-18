function pieceOfPie(array, pie1, pie2) {
    const start = array.indexOf(pie1);
    const end = array.indexOf(pie2);

    const result = array.slice(start, end + 1);

    return result;
}