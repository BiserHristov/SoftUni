class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`
        } else if (this._likes.length == 1) {
            return `${this._likes[0]} likes this article!`
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`
        }
    }

    like(username) {
        let user = this._likes.find(u => u == username)

        if (user) {
            throw new Error("You can't like the same article twice!")
        } else if (username == this.creator) {
            throw new Error("You can't like your own articles!");
        } else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`
        }
    }

    dislike(username) {
        let user = this._likes.find(u => u == username)

        if (!user) {
            throw new Error("You can't dislike this article!")
        }

        this._likes = this._likes.filter(u => u != username)
        return `${username} disliked ${this.title}`
    }

    comment(username, content, id) {
        let serchedComment = this._comments.find(c => c.Id == id);
        //If it`s comment
        if (id == 'undefined' || !serchedComment) {
            let newCommentId = 1;
            if (this._comments.length > 0) {
                newCommentId = this._comments.length + 1; ///????? -1?
            }

            serchedComment = {
                Id: newCommentId,
                Username: username,
                Content: content,
                Replies: []
            }

            this._comments.push(serchedComment);
            return `${username} commented on ${this.title}`
        }

        //If it`s reply
        let newReplyId = 1;
        let lastReply = serchedComment.Replies[serchedComment.Replies.length - 1];
        if (lastReply) {
            newReplyId = Number(lastReply.Id.toString().split('.')[1]) + 1;
        }

        let reply = {
            Id: Number(id + '.' + newReplyId),
            Username: username,
            Content: content
        }
        serchedComment.Replies.push(reply)

        return "You replied successfully"
    }

    toString(sortingType) {
        let result = [];

        result.push(`Title: ${this.title}`)
        result.push(`Creator: ${this.creator}`)
        result.push(`Likes: ${this._likes.length}`)
        result.push(`Comments:`)

        //Default is 'asc'
        if (sortingType == 'desc') {
            this._comments = this._comments
                .sort((curr, next) => { return next.Id - curr.Id })

            for (let i = 0; i < this._comments.length; i++) {
                let comment = this._comments[i];
                comment.Replies.sort((curr, next) => { return next.Id - curr.Id })
            }
        } else if (sortingType == 'username') {
            this._comments = this._comments
                .sort((curr, next) => { return curr.Username.localeCompare(next.Username) })

            for (let i = 0; i < this._comments.length; i++) {
                let comment = this._comments[i];
                comment.Replies.sort((curr, next) => { return curr.Username.localeCompare(next.Username) })
            }
        }
        this._comments.forEach(c => {
            result.push(`-- ${c.Id}. ${c.Username}: ${c.Content}`)

            if (c.Replies.length > 0) {
                c.Replies.forEach(r => {
                    result.push(`--- ${r.Id}. ${r.Username}: ${r.Content}`)
                })
            }
        })

        return result.join('\n').trim();
    }
}

// let art = new Article("My Article", "Anny");
// art.like("John");
// console.log(art.likes);
// art.dislike("John");
// console.log(art.likes);
// art.comment("Sammy", "Some Content");
// console.log(art.comment("Ammy", "New Content"));
// art.comment("Zane", "Reply", 1);
// art.comment("Jessy", "Nice :)");
// console.log(art.comment("SAmmy", "Reply@", 1));
// console.log()
// console.log(art.toString('username'));
// console.log()
// art.like("Zane");
// console.log(art.toString('desc'));


// John likes this article!
// My Article has 0 likes
// Ammy commented on My Article
// You replied successfully

// Title: My Article
// Creator: Anny
// Likes: 0
// Comments:
// -- 2. Ammy: New Content
// -- 3. Jessy: Nice :)
// -- 1. Sammy: Some Content
// --- 1.2. SAmmy: Reply@
// --- 1.1. Zane: Reply

// Title: My Article
// Creator: Anny
// Likes: 1
// Comments:
// -- 3. Jessy: Nice :)
// -- 2. Ammy: New Content
// -- 1. Sammy: Some Content
// --- 1.2. SAmmy: Reply@
// --- 1.1. Zane: Reply
