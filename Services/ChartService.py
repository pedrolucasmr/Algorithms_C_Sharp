import plotly as _plotly
import mysql.connector as _connector
from mysql.connector import Error
import sys
sys.path.append("../Data")
import time
for x in sys.path:
    print(x)
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
        cursor.callproc("GetRunResults",[algorithm])
        results=cursor.fetchall()
        if(cursor.with_rows):
            return results
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
    for i in list:
        sum=sum+i[2]
    return sum

def DivideInList(list):
    list10=[]
    list100=[]
    list1000=[]
    list10000=[]
    list100000=[]
    list1000000=[]
    for i in list:
        if(i[2]>=0 and i[2]<=99):
            list10.append(i)
        elif(i[2]>=100 and i[2]<=999):
            list100.append(i)
        elif(i[2]>=1000 and i[2]<=9999):
            list1000.append(i)
        elif(i[2]>=10000 and i[2]<=99999):
            list10000.append(i)
        elif(i[2]>=100000 and i[2]<=999999):
            list100000.append(i)
        elif(i>=1000000):
            list1000000.append(i)
    listOfLists=[list10,list100,list1000,list10000,list100000,list1000000]
    return listOfLists

def SingleAlgorithmChart(algorithm):
    results=GetRunTimeResults(algorithm)
    print(len(results))
    
    

SingleAlgorithmChart("Quick Sort")
#GetRuns()
#GetSpecificRun("Bubble Sort")
#GetRunTimeResults("Bubble Sort")
#GetAllRunsTimeResults()