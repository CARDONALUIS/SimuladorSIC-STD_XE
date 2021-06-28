grammar GramaticaSIC_STD;

/*
 * Parser Rules 
 */

/* 
programa: inicio proposiciones final                       #programIni;

inicio:  etiqueta TAB DIRSTART TAB NUM FINL                     #inicioEti
        | proposicion			                            #inicioPro;

final : TAB DIREND TAB entrada EOF               #finEntrada
       | etiqueta TAB DIREND TAB entrada EOF                     #endfinaltotal
       | TAB DIREND EOF                                       #finalSinEntrada
       ;
       
entrada: ID |  ;

proposiciones: proposiciones proposicion                   #proposicionDuplicada
        | proposicion	                                    #proposicionInst
        ;

//
//proposicion: instruccion                                    #propsicionInstruccion
//             | directiva						            #propsicionDirectiva
//             |.                                                #error;
//
//instruccion: etiqueta TAB CODOP TAB opinstruccion FINL		#instruccionVisitor
//            | etiqueta TAB TRSUB FINL                   #instrRSUB;

proposicion: formato                                    #propsicionInstruccion
             | directiva						            #propsicionDirectiva
             |.                                                #error;

formato: for1|for2|for3|for4  #tipoDeFormato;

for3:etiqueta TAB CODOP TAB opinstruccion FINL		#instruccionVisitor
   | etiqueta TAB TRSUB FINL                   #instrRSUB;

for1: OP1;

for2: OP2 NUM | OP2 REG | OP2 REG ',' REG| OP2 REG ',' NUM;






directiva: etiqueta TAB TIPODIRECTIVA TAB opdirectiva FINL  #directivaExisten;


etiqueta: ID | | COMPNUM;

opinstruccion: (ID indexado) |  | (COMPNUM indexado); 

//numComp: (COMPNUM indexado) | ;

indexado: INDICE |  ;

opdirectiva: NUM | CONSTHEX | CONSTCAD  ;

tipoByte: CONSTHEX | CONSTCAD ; 

//Lexer Rules

TIPODIRECTIVA: 'RESW' | 'RESB' | 'WORD' | 'BYTE';

DIRSTART: 'START';

DIREND: 'END';

TRSUB: 'RSUB';

CODOP: 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCH' 
          | 'LDL' | 'LDX' | 'MUL'  | 'OR'  | 'RD' | 'STA'	| 'STCH' | 'STL' | 'STSW' | 
            'STX' | 'SUB' | 'TD'   | 'TIX' | 'WD' ;

CONSTCAD: 'C\''[a-zA-Z0-9]+'\'';

CONSTHEX: 'X\''[0-9A-F]+'\'';

ID: [A-Z]+;

DIRBYTE: 'BYTE';

FINL:['\r\n']+;

TAB:['\t']*;

NUM: ('0'..'9' | 'a'..'f' | 'A'..'F')+('H')? | ('0'..'9' | 'a'..'f' | 'A'..'F')+('h')?;

INDICE: ', X' | ',X';

COMPNUM:[A-Z0-9]+;

WS : [\r\r' ']+ ->skip;

OP1: 'FIX' | 'FLOAT' | 'HIO' | 'NORM' | 'SIO' | 'TIO';

OP2: 'ADDR' | 'CLEAR' | 'COMPR' | 'DIVR' | 'MULR' | 'RMO' | 'SHIFTL' | 'SHIFTR' | 'SUBR' | 'SVC' | 'TIXR';

REG: '0' | '1' | '2' | '8' | '9' | '3' | '4' | '5' | '6';

//final: EOF| \r\n;
*/


programa: inicio proposiciones final                       #programIni;

inicio:  etiqueta TAB DIRSTART TAB NUM FINL                     #inicioEti
        | proposicion			                            #inicioPro;

final : TAB DIREND TAB entrada EOF               #finEntrada
       | etiqueta TAB DIREND TAB entrada EOF                     #endfinaltotal
       | TAB DIREND EOF                                       #finalSinEntrada
       ;
       
entrada: ID |  ;

proposiciones: proposiciones proposicion                   #proposicionDuplicada
        | proposicion	                                    #proposicionInst
        ;


proposicion: instruccion                                    #propsicionInstruccion
             | directiva						            #propsicionDirectiva
             |.                                                #error;
             



instruccion: etiqueta TAB CODOP TAB opinstruccion FINL		#instruccionVisitor
            | etiqueta TAB TRSUB FINL                   #instrRSUB;


directiva: etiqueta TAB TIPODIRECTIVA TAB opdirectiva FINL  #directivaExisten;


etiqueta: ID | | COMPNUM;

opinstruccion: (ID indexado) |  | (COMPNUM indexado); 

/*numComp: (COMPNUM indexado) | ;*/

indexado: INDICE |  ;

opdirectiva: NUM | CONSTHEX | CONSTCAD  ;

tipoByte: CONSTHEX | CONSTCAD ; 

//Lexer Rules

TIPODIRECTIVA: 'RESW' | 'RESB' | 'WORD' | 'BYTE';

DIRSTART: 'START';

DIREND: 'END';

TRSUB: 'RSUB';

CODOP: 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCH' 
          | 'LDL' | 'LDX' | 'MUL'  | 'OR'  | 'RD' | 'STA'	| 'STCH' | 'STL' | 'STSW' | 
            'STX' | 'SUB' | 'TD'   | 'TIX' | 'WD' ;

CONSTCAD: 'C\''[a-zA-Z0-9]+'\'';

CONSTHEX: 'X\''[0-9A-F]+'\'';

ID: [A-Z]+;

DIRBYTE: 'BYTE';

FINL:['\r\n']+;


TAB:['\t']*;

NUM: ('0'..'9' | 'a'..'f' | 'A'..'F')+('H')? | ('0'..'9' | 'a'..'f' | 'A'..'F')+('h')?;

INDICE: ', X' | ',X';

COMPNUM:[A-Z0-9]+;

WS : [\r\r' ']+ ->skip;

//final: EOF| \r\n;

