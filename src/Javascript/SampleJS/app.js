function writeln(a)
{
    console.log(a)
}
function main()
{
    let numbers = [1, 21, 30, 41, 5]

    if (numbers.some(val => val % 2 === 0))
        writeln("En az bir tane çift sayı var")
    else
        writeln("Hiç çift yok")}

main()
