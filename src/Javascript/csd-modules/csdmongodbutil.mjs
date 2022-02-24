import mongodb from 'mongodb'

const MongoClient = mongodb.MongoClient
const mongoDbOptions = {useNewUrlParser: true, useUnifiedTopology: true}

const createMongoClientByUrl = url => new MongoClient(url, mongoDbOptions)
const createMongoClient = (host, port) => createMongoClientByUrl(`mongodb://${host}:${port}`)

export {createMongoClientByUrl, createMongoClient}


