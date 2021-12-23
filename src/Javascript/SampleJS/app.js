/*
Sınıf Çalışması: Parametresi ile aldığı number türden bir sayının basamak sayısını döndüren digitsCount fonksiyonunu
yazınız
 */
function writeln(a)
{
    console.log(a)
}

function digitsCount(val)
{
    if (!val)
        return 1

    let count = 0

    while (val) {
        ++count;
        val = parseInt(val / 10)
    }

    return count
}

function main()
{
    writeln(digitsCount(0))
    writeln(digitsCount(-123))
    writeln(digitsCount(123))
    writeln(digitsCount("ankara"))
}
main()

