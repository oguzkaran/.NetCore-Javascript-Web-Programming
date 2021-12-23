function writeln(a)
{
    console.log(a)
}

function isPrime(val)
{
    if (val <= 1)
        return false

    if (val % 2 == 0)
        return val == 2

    if (val % 3 == 0)
        return val == 3

    if (val % 5 == 0)
        return val == 5

    if (val % 7 == 0)
        return val == 7

    for (let i = 11; i * i<= val; i += 2)
        if (val % i == 0)
            return false

    return true
}

function getPrime(n)
{
    let count = 0
    let val = 2

    for (;;) {
        if (isPrime(val))
            ++count

        if (count == n)
            return val

        ++val
    }
}

function main()
{
    writeln(getPrime(1))
    writeln(getPrime(2))
    writeln(getPrime(3))
    writeln(getPrime(20))
}

main()
