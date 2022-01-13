import {writeLine} from "./csdstdioutil.mjs";
import {createComplex, createPoint, createRandomPoint, getOrigin} from "./csdmatutil.mjs";

function main()
{
    const {real, imag} = createComplex()

    writeLine(`${real} + ${imag}i`)

    const {x, y} = getOrigin()

    writeLine(`(${x}, ${y})`)
}

main()


