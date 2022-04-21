import {writeLine, writeErrLine} from '../../../csd-modules/csdstdioutil.mjs'
import dotenv from 'dotenv'
import pg from 'pg'

process.on('uncaughtException', err => writeErrLine(err))
const config = dotenv.config()

const env = process.env
const connectionInfo = {host:env.PG_HOST, port: env.PG_PORT, user: env.PG_USER, password: env.PG_PASSWORD, database: env.PG_DATABASE }
const db = new pg.Client(connectionInfo);

const CREATE_TASK_TABLE_SQL = 'create table if not exists tasks (task_id serial primary key, task text not null, date date default(current_date) not null);'
const INSERT_TASK_SQL = `insert into tasks (task) values ($1);`
const GET_TASKS_SQL = 'select * from tasks'
//TODO: iki tane ay arasındaki task'ları getiren fonksiyonu yazınız
const task = process.argv[2]

function throwIf(err)
{
    if (err)
        throw err
}

function listTasksCallback(err, data)
{
    throwIf(err)

    data.rows.forEach(t => writeLine(`${t.task_id}, ${t.task}, ${t.date}`))
    db.end()
}

function listTasks()
{
    db.query(GET_TASKS_SQL, (err, data) =>  listTasksCallback(err, data))
}


function insertTaskCallback(err)
{
    throwIf(err)

    listTasks()
}

function createTableCallback(err)
{
    throwIf(err)

    if (task)
        db.query(INSERT_TASK_SQL, [task], err => insertTaskCallback(err))
    else
        listTasks()
}


function connectCallback(err)
{
    throwIf(err)

    db.query(CREATE_TASK_TABLE_SQL, err => createTableCallback(err))
}

db.connect(err => connectCallback(err))

