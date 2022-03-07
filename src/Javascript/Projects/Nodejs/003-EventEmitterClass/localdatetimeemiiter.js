const EventEmitter = require("events")

class LocalDateTimeEmitter extends EventEmitter {
    intervalCallback()
    {
        let now = new Date()

        super.emit("now", "test")
    }

    start()
    {
        setInterval(this.intervalCallback, 1000)
    }
}

export {LocalDateTimeEmitter}
