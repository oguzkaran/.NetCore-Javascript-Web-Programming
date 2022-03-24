import test from 'tape';
import {isPrime} from '../../csd-modules/csdnumberutil.mjs';

const primes = [20, 30, -1, 1, 100, 69, 55]

function testIsPrimeCallback(t)
{
    t.plan(primes.length)

    for (let val of primes)
        t.notOk(isPrime(val), "Not Prime test")
}

function main()
{
    test("test isPrime for prime Numbers", testIsPrimeCallback)
}

main()
