import test from 'tape';
import {createRandomPoints} from '../../csd-modules/mumathutil.mjs'

function testCallback(t)
{
    t.plan(1)

    t.throws(createRandomPoints(10, 10, 5))
}

function main()
{
    test("createRandomPointsThrowTest", testCallback)
}

main()
