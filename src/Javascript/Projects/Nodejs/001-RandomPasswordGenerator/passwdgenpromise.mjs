import {open} from 'fs/promises';
import fs from 'fs';
import {randomTextTR} from '../../../csd-modules/csdstringutil.mjs';
import {checkForLengthEqual} from '../../../csd-modules/csdcommandlineargsutil.mjs';

async function generatePasswords(filepath, count, n)
{
    try {
        let fd = (await open(filepath, "w")).fd

        while (count--) {
            let text = randomTextTR(n)
            fs.writeSync(fd, text + '\r\n')
        }
    }
    catch (err) {
        exitFail(err.message)
    }
}


function main()
{
    checkForLengthEqual(process.argv, 5, "usage:node passwdgen.mjs filename count nchars")

    let filepath = process.argv[2];
    let count = parseInt(process.argv[3]);
    let n = parseInt(process.argv[4])

    generatePasswords(filepath, count, n)
}

main()
