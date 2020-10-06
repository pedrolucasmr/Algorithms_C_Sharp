import plotly.graph_objects as _plotly
import mysql.connector as _connector
from mysql.connector import Error
import sys
sys.path.append("../Data")
import datetime
import dbConfig

_dbConfig=dbConfig.readDbConfig()

def GetRuns():
    try:
        connection=_connector.Connect(**_dbConfig)
        connection._open_connection()
        cursor=connection.cursor()
        cursor.callproc("GetAllRuns")
        for result in cursor.stored_results():
            print(result.fetchall())
    except Error as e:
       print(e)
    finally:
        cursor.close()
        connection.close()

def GetSpecificRun(algorithm):
    try:
        connection=_connector.connect(**_dbConfig)
        connection._open_connection()
        cursor=connection.cursor()
        cursor.callproc("GetSpecificRuns",[algorithm])
        for result in cursor.stored_results():
            print(result)
    except Error as e:
        print(e)
    finally:
        cursor.close()
        connection.close()

def GetRunTimeResults(algorithm):
    try:
        connection=_connector.connect(**_dbConfig)
        connection._open_connection()
        cursor=connection.cursor(dictionary=True)
        results=cursor.callproc("GetRunResults",[algorithm,0,0])
        if(cursor.with_rows):
                return results.fetchall()
    except Error as e:
        print(e)
    finally:
        cursor.close()
        connection.close()

def GetAllRunsTimeResults():
    try:
        connection=_connector.connect(**_dbConfig)
        connection._open_connection()
        cursor=connection.cursor()
        cursor.callproc("GetAllRunsResults")
        results=cursor.fetchall()
        for result in results:
            print(result)
        return results
    except Error as e:
        print(e)
    finally:
        cursor.close()
        connection.close()

def ArithmeticAverage(list):
    sum=0
    print(list[20])
    for i in list:
        if(list[i]<0):
            currentValue=currentValue*-1
        sum=sum+i[1]
    results=(sum/len(list))/1000
    print(sum)
    print(len(list))
    print(results)
    return (results)

def ZeroToAHundred(x):
    if(x[2]>=0 and x[2]<=99):
        return True
    else:
        return False
def AHundredToAThousand(x):
    if(x[2]>=100 and x[2]<=999):
        return True
    else:
        return False
def AThousandToTenThousand(x):
    if(x[2]>=1000 and x[2]<=9999):
        return True
    else:
        return False
def TenThousandToAHundredThousand(x):
    if(x[2]>=10000 and x[2]<=99999):
        return True
    else:
        return False
def AHundredThousandToAMillion(x):
    if(x[2]>= 100000):
        return True
    else:
        return False

def SingleAlgorithmChart(algorithm):
    results=GetRunTimeResults(algorithm)
    for i in results:
        print(i)
    dozens=list(filter(ZeroToAHundred,results))
    hundreds=list(filter(AHundredToAThousand,results))
    thousands=list(filter(AThousandToTenThousand,results))
    dozensOfThousands=list(filter(TenThousandToAHundredThousand,results))
    hundredsofThousands=list(filter(AHundredThousandToAMillion,results))
    yAxis=[ArithmeticAverage(dozens),ArithmeticAverage(hundreds),ArithmeticAverage(thousands),ArithmeticAverage(dozensOfThousands),ArithmeticAverage(hundredsofThousands)]
    xAxis=["Dezenas","Centenas","Milhares","Dezenas de Milhares","Centenas de milhares"]
    figure=_plotly.Figure([_plotly.Bar(x=xAxis,y=yAxis)])
    figure.show()

SingleAlgorithmChart("Bubble Sort")
#GetRuns()
#GetSpecificRun("Bubble Sort")
#GetRunTimeResults("Bubble Sort")
#GetAllRunsTimeResults()