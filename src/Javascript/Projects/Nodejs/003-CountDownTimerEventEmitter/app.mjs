import {CountDownTimer} from '../../../csd-modules/csdcountdowntimer.mjs'
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'

function main()
{
    let cdt = new CountDownTimer(10000, 1000)

    cdt.start()
    cdt.on("tick", ms => writeLine(ms / 1000))
    cdt.on('finished', () => writeLine("Finished"))
    writeLine("main ands")
}

main()


