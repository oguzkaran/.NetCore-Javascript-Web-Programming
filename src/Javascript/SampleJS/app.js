function writeln(a)
{
    console.log(a)
}

function main()
{
    let result = bar() && foo() || tar()

    writeln(result)
}

function foo()
{
    writeln("foo")
    return true
}

function bar()
{
    writeln("bar")
    return false
}
function tar()
{
    writeln("tar")
    return false
}


main()
