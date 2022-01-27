import {randomInt} from "./csdrandomutil.mjs";
import {writeLine} from "./csdstdioutil.mjs";

const doWork = timeout => {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            let val = randomInt(-10, 10)

            console.log(`val=${val}`)
            if (val > 0)
                resolve(val)
            else
                reject("not positive value ")
        }, timeout)
    })
}

async function main()
{
    try {
        const val = await doWork(2000)

        writeLine(`val=${val}`)
    }
    catch (err) {
        writeLine(err.message)
    }
}

main()

writeLine("here")
