import http from 'http';
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'

function rootUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type':'text/plain'})
    res.end("Root url\r\n")
}

function helloTRUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type':'text/plain'})
    res.end("Merhaba arkadaşlar\r\n")
}

function helloENUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type':'text/plain'})
    res.end("Hi friends\r\n")
}

function notFoundUrlCallback(req, res)
{
    res.writeHead(404, {'Content-Type':'text/plain'})
    res.end("URL not found\r\n")
}

function serverCallback(req, res)
{
    writeLine(`url:${req.url}`)

    switch (req.url) {
        case '/':
            rootUrlCallback(req, res)
            break;
        case '/hello-tr':
            helloTRUrlCallback(req, res)
            break;
        case '/hello-en':
            helloENUrlCallback(req, res)
            break;
        default:
            notFoundUrlCallback(req, res)
    }
}

function main()
{
    const server = http.createServer(serverCallback)
    const port = 50500

    writeLine(`Server is listening on port:${port}`)
    server.listen(port)
}

main()

