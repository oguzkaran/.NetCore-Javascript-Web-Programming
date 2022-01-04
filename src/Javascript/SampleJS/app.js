function writeln(a)
{
    console.log(a)
}

let Device = function (name, host, port) {
    this.name = name
    this.host = host
    this.port = port

    this.toString = function () {return `${name} ${host}:${port}`}

    return this
}

function main()
{
    let dev = new Array(10)

    writeln(dev)
}

main()
