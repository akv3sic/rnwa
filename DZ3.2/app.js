const express = require('express')
const bodyParser = require('body-parser')
const mysql = require('mysql')

const app = express()
const port = process.env.PORT || 5003


app.use(bodyParser.urlencoded({ extended: false}))
app.use(bodyParser.json())

// MySQL
const pool = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'employees'
})


// get all employees
app.get('/employees', (rey, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        connection.query('SELECT * FROM employees LIMIT 10', (err, rows) => {
            connection.release() // return the connection to pool

            if(!err) {
                res.send(rows)
            } else 
            {
                console.log(err)
            }
        })
    })
})





app.listen(port, () => console.log(`Listening on port ${port}`))