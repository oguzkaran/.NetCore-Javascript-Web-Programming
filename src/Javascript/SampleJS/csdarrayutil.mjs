import {randomInt, randomDouble} from "./csdrandomutil.mjs";

const randomIntArray = (n, min, max) => {
    let result = []

    while (n--)
        result.push(randomInt(min, max))

    return result
}

const randomDoubleArray = (n, min, bound) => {
    let result = []

    while (n--)
        result.push(randomDouble(min, bound))

    return result
}

export {randomIntArray, randomDoubleArray}
