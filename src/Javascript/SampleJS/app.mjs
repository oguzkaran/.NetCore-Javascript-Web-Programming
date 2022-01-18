import {writeLine} from "./csdstdioutil.mjs";

function main()
{
    const divider = 1000 * 60 * 60 * 24 * 365

    let millis = Date.now() //new Date().getTime()

    writeLine(millis)
}

main()


