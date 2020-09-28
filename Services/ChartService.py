import plotly as _plotly
import mysql.connector as _connector
from mysql.connector import Error
import sys
sys.path.append("../Data")
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
        cursor=connection.cursor()
        cursor.callproc("GetRunResults",[algorithm])
        for result in cursor.stored_results():
            print(result.fetchall())
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
        for result in cursor.stored_results():
            print(result.fetchall())
    except Error as e:
        print(e)
    finally:
        cursor.close()
        connection.close()

def SingleAlgorithmChart(algorithm):
    print('c')
    


#GetRuns()
#GetSpecificRun("Bubble Sort")
#GetRunTimeResults("Bubble Sort")
#GetAllRunsTimeResults()