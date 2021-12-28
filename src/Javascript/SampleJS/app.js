function write(a)
{
    process.stdout.write(a)
}

function writeln(a)
{
    write(a === undefined ? '\n' : `${a}\n`)
}

function displayDevice()
{
    writeln(`Device Id:${this.id}`)
    writeln(`Device name:${this.name}`)
    writeln(`Device port:${this.port}`)
    writeln(`Device IP:${this.ip}`)
}


function main()
{
    let device = {
        id: 1,
        name: "test",
        port: 1234,
        ip: "192.168.2.234",
        display: displayDevice
    }

    device.display()
    device.port = 5765
    device.display()

}

main()
