1000000 CONSTANT NUMBER-MAX
NUMBER-MAX 8 / CONSTANT SET-SIZE

CREATE BITSET SET-SIZE ALLOT

: BITSET-INIT
    BITSET DUP SET-SIZE + SWAP DO 0 I C! LOOP ;

: BITSET! ( n -- )
    64 /MOD
    CELLS BITSET + SWAP 1 SWAP LSHIFT
    OVER @ OR SWAP ! ;

: BITSET@ ( n -- f )
    64 /MOD
    CELLS BITSET + SWAP 1 SWAP LSHIFT
    SWAP @ AND ;

: SKIP-NON-DIGIT ( -- n )
    BEGIN KEY DIGIT? 0= WHILE REPEAT ;

: GET-NUMBER ( -- n )
    0 SKIP-NON-DIGIT
    BEGIN
        SWAP 10 * +
        KEY DIGIT?
    0= UNTIL ;

: MAIN
    BITSET-INIT
    GET-NUMBER 0 DO
        GET-NUMBER
        BITSET!
    LOOP
    NUMBER-MAX 1+ 0 DO
        I BITSET@ IF I . CR THEN
    LOOP ;

MAIN BYE
