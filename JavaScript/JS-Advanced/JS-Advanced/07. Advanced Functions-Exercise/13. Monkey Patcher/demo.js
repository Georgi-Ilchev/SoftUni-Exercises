function solve(command) {
    if (command === 'upvote') return this.upvotes++;
    if (command === 'downvote') return this.downvotes++;

    let upvote = this.upvotes;
    let downvote = this.downvotes;
    let totalVotes = upvote + downvote;
    let balance = upvote - downvote;

    function ratingState() {
        if (totalVotes < 10) return 'new';
        if (upvote > totalVotes * 0.66) return 'hot';
        if (balance >= 0 && totalVotes > 100) return 'controversial';
        if (balance < 0) return 'unpopular';
        return 'new';
    }

    if (totalVotes > 50) {
        let inflateVote = Math.ceil(Math.max(upvote, downvote) * 0.25);
        return [upvote + inflateVote, downvote + inflateVote, balance, ratingState()];
    }

    return [upvote, downvote, balance, ratingState.call(this)];
}


solve = (() => {
    const commands = {
        upvote: (post) => post.upvotes++,
        downvote: (post) => post.downvotes++,
        score: (post) => {
            let { upvotes, downvotes } = post;
            let total = upvotes + downvotes;

            let obfuscated = Math.ceil(0.25 * Math.max(upvotes, downvotes));
            let obfuscatedUpVotes = upvotes + obfuscated;
            let obfuscatedDownVotes = downvotes + obfuscated;
            let balance = obfuscatedUpVotes - obfuscatedDownVotes;

            let rating = '';

            if (total < 10) {
                rating = 'new';
            } else if (upvotes > total * 0.66) {
                rating = 'hot';
            } else if (balance >= 0 && (upvotes > 100 || downvotes > 100)) {
                rating = 'controversial';
            } else if (balance < 0) {
                rating = 'unpopular';
            } else {
                rating = 'new';
            }
            if (total > 50) {
                return [obfuscatedUpVotes, obfuscatedDownVotes, balance, rating];
            }
            return [upvotes, downvotes, balance, rating];
        }
    };

    return { call: (post, command) => commands[command](post) }
})();