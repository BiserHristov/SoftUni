(function () {
    String.prototype.ensureStart = function (word) {
        let curr = this;
        if (!this.startsWith(word)) {
            curr = word + curr;
        }

        return curr.toString();

    }

    String.prototype.ensureEnd = function (word) {
        let curr = this;
        if (!curr.endsWith(word)) {
            curr += word;
        }

        return curr.toString();

    }

    String.prototype.isEmpty = function () {

        return this.length == 0
    }

    String.prototype.truncate = function (n) {

        let result = this;

        if (n < 4) {
            return '.'.repeat(n)
        }

        if (this.indexOf(' ') < 0) {
            return this.substring(0, n - 3) + '...';
        }

        if (this.length > n) {
            let resultAsArr = this.split(' ')

            while (resultAsArr.join(' ').length + 3 > n) {
                resultAsArr.pop();
            }

            return resultAsArr.join(' ') + '...';
        }

        return result.toString();

    }

    String.format = function (str, ...params) {

        let result = str;
        let paramsArr = [...params];

        paramsArr.forEach((value, index) => {
            result=result.replace(`{${index}}`, value)
        })

        return result.toString();

    }

})()