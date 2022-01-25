import {write, writeLine} from "./csdstdioutil.mjs";
import {Random} from "./csdrandom.mjs";

function main()
{
    for (let i = 0; i < 10; ++i)
        write(Random.nextInt(1, 100) + " ")

    writeLine("\n-------------------------------------")

    for (let i = 0; i < 10; ++i)
        writeLine(Random.nextNumber(3.4, 7.789))

    writeLine("\n-------------------------------------")

    for (let i = 0; i < 10; ++i)
        writeLine(Random.nextBoolean())
}

main()
