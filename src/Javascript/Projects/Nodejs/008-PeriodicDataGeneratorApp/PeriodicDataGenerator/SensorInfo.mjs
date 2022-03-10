class SensorInfo {
    constructor(name, host, port, data)
    {
        this.name = name
        this.host = host
        this.port = port
        this.data = data
        this.date = new Date()
    }
    //...
}

export {SensorInfo}
