/*
    TODO: Komut satırı argümanı ile alınan eşik değerine göre 5 saniyede bir bu eşik değerinden büyük veriye sahip
    sensörlerin isimleri ile birlikte data ve tarihleri getiren uygulamayı yazınız
 */

import {createMongoClient} from '../../../../csd-modules/csdmongodbutil.mjs'
import {writeErrLine, writeLine} from '../../../../csd-modules/csdstdioutil.mjs'


process.on("uncaughtException", err => writeErrLine(err.message))

function connectForInsertCallback(err, client)
{
    if (err)
        throw  err

    const db = client.db(process.argv[4])
    const sensors = db.collection(process.argv[5])
    sensors.find({data: {$gt: parseInt(process.argv[6])}}).toArray((err, result) => result.forEach(s => writeLine(JSON.stringify(s))))
}

function readPeriodicDataCallback()
{
    createMongoClient(process.argv[2], parseInt(process.argv[3])).connect(connectForInsertCallback)
}

function main()
{
    setInterval(readPeriodicDataCallback, 500)
}

main()








