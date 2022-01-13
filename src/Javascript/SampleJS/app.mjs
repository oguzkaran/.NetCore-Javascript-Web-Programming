import {writeLine, write} from "./csdstdioutil.mjs";

function main()
{
    let a = [1, 2, 3, 5, 6, 7, 8, 9]


    for (let val of a)
        write(`${val} `)

    writeLine()

    a.length = 7

    for (let val of a)
        write(`${val} `)
}

main()
