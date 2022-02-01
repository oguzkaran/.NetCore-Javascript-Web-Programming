import fs from 'fs';
import {randomTextTR} from '../../../csd-modules/csdstringutil.mjs';
import {checkForLengthEqual} from '../../../csd-modules/csdcommandlineargsutil.mjs';
import {exitFail} from '../../../csd-modules/csderrorutil.mjs';

function openFileCallback(err, fd, count, n)
{
    if (err)
        exitFail(err.message)

    while (count--) {
        let text = randomTextTR(n)
        fs.writeSync(fd, text + '\r\n')
    }
}


function generatePasswords(filepath, count, n)
{
    fs.open(filepath, "w", (err, fd) => openFileCallback(err, fd, count, n))
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
