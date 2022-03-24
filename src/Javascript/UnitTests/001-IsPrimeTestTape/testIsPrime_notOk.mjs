import test from 'tape';
import {isPrime} from '../../csd-modules/csdnumberutil.mjs';

const primes = [2, 3, 19, 100003, 97]

function testIsPrimeCallback(t)
{
    t.plan(primes.length)

    for (let val of primes)
        t.ok(isPrime(val), "Prime test")
}

function main()
{
    test("test isPrime for prime Numbers", testIsPrimeCallback)
}

main()
