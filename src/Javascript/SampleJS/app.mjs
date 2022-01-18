import {writeLine} from "./csdstdioutil.mjs";

function main()
{
    let s = "Bugün hava  çok.........           güzel"
    let words = s.split(/[ .]/)

    for (let word of words)
        writeLine(`(${word})`)
}

main()

