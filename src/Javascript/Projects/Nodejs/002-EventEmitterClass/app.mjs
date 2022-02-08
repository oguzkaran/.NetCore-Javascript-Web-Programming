import {LocalDateTimeEmitter} from "./localdatetimeemiiter.mjs";
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'

function main()
{
    const ldte = new LocalDateTimeEmitter()

    ldte.start()
    ldte.on("now", now => writeLine(`Now1:${now}`))
    ldte.on("now", now => writeLine(`Now2:${now}`))
}

main()

