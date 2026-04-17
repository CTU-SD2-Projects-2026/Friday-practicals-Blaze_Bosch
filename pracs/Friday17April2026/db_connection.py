import pyodbc

def connect_db():
    try:
        conn = pyodbc.connect(
            'DRIVER={SQL Server};'
            'SERVER=LAPTOP-D8O1G72G\\SQLEXPRESS;'
            'DATABASE=ApexLogisticsDB;'
            'Trusted_Connection=yes;'
        )
        return conn
    except Exception as e:
        print("Connection failed:", e)
        return None

#####################################

#The code below should be in main.py

from db_connection import connect_db
def test_connection():
conn = connect_db()
    if conn:
        print("Connected successfully!")
        cursor = conn.cursor()
        
        cursor.execute("SELECT * FROM tblProducts")
        rows = cursor.fetchall()
        
        for row in rows:
            print(row)
        
        conn.close()
    else:
        print("Connection failed.")

if name == "main":
test_connection()
