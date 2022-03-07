import EventEmitter from 'events';

class LocalDateTimeEmitter extends EventEmitter {
    intervalCallback()
    {
        let now = new Date()

        this.emit("now", now)
    }

    start()
    {
        setInterval(() => this.intervalCallback(), 1000)
    }
}

export {LocalDateTimeEmitter}
