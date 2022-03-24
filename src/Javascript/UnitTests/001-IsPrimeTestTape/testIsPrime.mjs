import test from 'tape';
import {isPrime} from '../../csd-modules/csdnumberutil.mjs';

/*
    Bir dosyada çeşitli sayılar ve asal olup olmadıkları bilgileri aşağıdaki örnekteki gibi verilmiş olsun
        19 true
        22 false
        ...
    Buna göre bu sayıları dosyadan okuyarak test işlemi yapan aşağıdaki testIsPrimeCallback fonksiyonunu yazınız
*/

function testIsPrimeCallback(t)
{
    //TODO:
}

function main()
{
    test("test isPrime for prime Numbers", testIsPrimeCallback)
}

main()
