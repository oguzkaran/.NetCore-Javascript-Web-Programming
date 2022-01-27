import {writeLine} from "./csdstdioutil.mjs";
import {MathError} from "./csdexception.mjs";

class MathUtil {
    static log(value)
    {
        if (value < 0)
            throw new MathError("Belirsiz", -1)

        if (value === 0)
            throw new MathError("Tanımsız", 0)

        return Math.log(value)
    }
}




function main()
{
    let min = -10
    let max = 10

    for (let i = 0; i < 100; ++i) {
        try {
            let result = MathUtil.log(Math.random() * (max - min) + min)

            writeLine(result)
        }
        catch (ex) {
            writeLine(ex.errorMessage)
        }
    }
}


main()
