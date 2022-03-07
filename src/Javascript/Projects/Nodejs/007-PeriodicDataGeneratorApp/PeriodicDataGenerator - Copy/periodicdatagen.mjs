import {SensorInfo} from "./SensorInfo.mjs";
import {createMongoClient} from '../../../csd-modules/csdmongodbutil.mjs'
import {writeErrLine, writeLine} from '../../../csd-modules/csdstdioutil.mjs'
import {randomTextEN} from '../../../csd-modules/csdstringutil.mjs'
import {Random} from '../../../csd-modules/csdrandom.mjs'

process.on("uncaughtException", err => writeErrLine(err.message))

const getRandomHost = () => `${Random.nextInt(0, 256)}.${Random.nextInt(0, 256)}.${Random.nextInt(0, 256)}.${Random.nextInt(0, 256)}`

function getRandomSensor()
{
    const name = randomTextEN(Random.nextInt(5, 11))
    const host = getRandomHost()
    const port = Random.nextInt(1024, 65536)
    const data = Random.nextDouble(-100, 100)

    return new SensorInfo(name, host, port, data)
}

function connectForInsertCallback(err, client)
{
    if (err)
        throw  err

    const db = client.db(process.argv[4])
    const sensors = db.collection(process.argv[5])
    sensors.insertOne(getRandomSensor(), err => {if (err) throw err})
}

function insertPeriodicDataCallback()
{
    createMongoClient(process.argv[2], parseInt(process.argv[3])).connect(connectForInsertCallback)
}

function main()
{
    const count = parseInt(process.argv[6])

    for (let i = 0; i < count; ++i)
        setInterval(insertPeriodicDataCallback, 1)
}

main()

/*
TODO: Komut satırı argümanı ile alınan eşik değerine göre 5 saniyede bir bu eşik değerinden büyük veriye sahip
sensörlerin isimleri ile birlikte data ve tarihleri getiren bir interval' ayrı bir uygulama olarak yazınız
 */






