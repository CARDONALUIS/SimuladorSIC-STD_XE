grammar GramaticaSIC_XE;


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


proposicion:  formato                                    #propsicionInstruccion
             | directiva						            #proposicionDirectiva
             |.                                                #error;
             
formato: for1  #formato1 
        |for2    #formato2
        |for34   #formato3
        ;

for1: etiqueta TAB OP1 FINL   ;


for2: etiqueta TAB OP2 TAB registros FINL;

//for3: etiqueta TAB CODOP TAB opinstruccion FINL		#instruccionVisitor
//            | etiqueta TAB TRSUB FINL                   #instrRSUB;

for34:  etiqueta TAB CODOP TAB simple FINL          #visformato3_SIM
      | etiqueta TAB TRSUB FINL                   #visinstrRSUB
      | etiqueta TAB CODOP TAB indirecto FINL          #visformato3_IND
      | etiqueta TAB CODOP TAB inmediato FINL          #visformato3_INM
      
      | etiqueta TAB '+'CODOP TAB simple FINL          #visformato4_SIM
      | etiqueta TAB '+'CODOP TAB indirecto FINL          #visformato4_IND
      | etiqueta TAB '+'CODOP TAB inmediato FINL          #visformato4_INM;



directiva:  etiqueta TAB 'BASE' TAB opBase FINL                  #directivaBase
           |etiqueta TAB TIPODIRECTIVA TAB opdirectiva FINL  #directivaExisten
          ;
            

etiqueta: ID | | COMPNUM;

simple: ID indexado  | COMPNUM indexado | NUM indexado; 

indirecto: '@'ID| '@'COMPNUM | '@'NUM;

inmediato: '#'ID| '#'COMPNUM | '#'NUM;
/*numComp: (COMPNUM indexado) | ;*/

indexado: INDICE?  ;

opdirectiva: NUM | CONSTHEX | CONSTCAD |COMPNUM;

tipoByte: CONSTHEX | CONSTCAD ; 

registros: NUM | REG | REG ',' NUM | REGCONV;

opBase: ID | COMPNUM ;


//Lexer Rules


OP1: 'FIX' | 'FLOAT' | 'HIO' | 'NORM' | 'SIO' | 'TIO';

OP2: 'ADDR' | 'CLEAR' | 'COMPR' | 'DIVR' | 'MULR' | 'RMO' | 'SHIFTL' | 'SHIFTR' | 'SUBR' | 'SVC' | 'TIXR';

REG: 'A' | 'X' | 'L' | 'CP' | 'SW' | 'B' | 'S' | 'T' | 'F';

REGCONV: REG',A' | REG',X' | REG',L' | REG',CP' | REG',SW' | REG',B' | REG',S' | REG',T' | REG',F'
       REG', A' | REG', X' | REG', L' | REG', CP' | REG', SW' | REG', B' | REG', S' | REG', T' | REG', F';

SUMEXT: '+';

TIPODIRECTIVA: 'RESW' | 'RESB' | 'WORD' | 'BYTE';


DIRSTART: 'START';

DIREND: 'END';

TRSUB: 'RSUB';

CODOP: 'ADD'| 'ADDF' | 'AND' | 'COMP' | 'COMPF' |  'DIV' | 'DIVF' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDB' | 'LDCH' | 'LDF' 
          | 'LDL' | 'LDS' | 'LDT' | 'LDX' | 'MUL' | 'MULF' | 'LPS' | 'OR'  | 'RD' | 'STA' | 'STB' | 'SSK' | 'STCH' | 'STF' | 'STI' | 'STL' | 'STS' | 'STSW' | 
           'STX' | 'STT' | 'SUB' | 'SUBF' | 'TD'  | 'TIX' | 'WD' ;

CONSTCAD: 'C\''[a-zA-Z0-9]+'\'';

CONSTHEX: 'X\''[0-9A-F]+'\'';

ID: [A-Z]+;

//COMA:[',']+;


DIRBYTE: 'BYTE';

FINL:['\r\n']+;

TAB:['\t']*;

NUM: ('0'..'9' | 'a'..'f' | 'A'..'F')+('H')? | ('0'..'9' | 'a'..'f' | 'A'..'F')+('h')?;

INDICE: ', X' | ',X';

COMPNUM:[A-Z0-9]+;

WS : [\r\r' ']+ ->skip;



//final: EOF| \r\n;