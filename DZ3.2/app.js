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

/*************************************/
/************ EMPLOYEES **************/
/*************************************/

// GET /employees
app.get('/employees', (req, res) => {
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


// GET /employees/:id
app.get('/employees/:id', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        connection.query('SELECT * FROM employees WHERE emp_no = ?', [req.params.id], (err, rows) => {
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

// POST /employees
app.post('/employees', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        const params = req.body
        console.log(params)
        connection.query('INSERT INTO employees SET ?', params, (err, rows) => {
            connection.release() // return the connection to pool

            if(!err) {
                res.send(`Zaposlenik ${params.first_name} ${params.last_name} uspješno dodan.`)
            } else 
            {
                console.log(err)
            }
        })
    })
})

// PUT /employees/:id
app.put('/employees', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        const { emp_no, birth_date, first_name, last_name, gender, hire_date } = req.body
        console.log(req.body)
        connection.query('UPDATE employees SET birth_date = ?, first_name = ?, last_name = ?, gender = ?, hire_date = ? WHERE emp_no = ?', [birth_date, first_name, last_name, gender, hire_date, emp_no], (err, rows) => {
            connection.release() // return the connection to pool

            if(!err) {
                res.send(`Zaposlenik s ID-em ${emp_no} uspješno ažuriran.`)
            } else 
            {
                console.log(err)
            }
        })
    })
})

/*************************************/
/*********** DEPARTMENTS *************/
/*************************************/

// GET /departments
app.get('/departments', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        connection.query('SELECT * FROM departments LIMIT 10', (err, rows) => {
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


// GET /departments/:id
app.get('/departments/:id', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        connection.query('SELECT * FROM departments WHERE dept_no = ?', [req.params.id], (err, rows) => {
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

// POST /departments
app.post('/departments', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        const params = req.body
        console.log(params)
        connection.query('INSERT INTO departments SET ?', params, (err, rows) => {
            connection.release() // return the connection to pool

            if(!err) {
                res.send(`Odjel ${params.dept_name}  uspješno dodan.`)
            } else 
            {
                console.log(err)
            }
        })
    })
})

// PUT /employees/:id
app.put('/departments', (req, res) => {
    pool.getConnection((err, connection) => {
        if(err) throw err
        console.log(`connected as id ${connection.threadId}`)

        const { dept_no, dept_name } = req.body
        console.log(req.body)
        connection.query('UPDATE departments SET dept_name = ? WHERE dept_no = ?', [dept_name, dept_no], (err, rows) => {
            connection.release() // return the connection to pool

            if(!err) {
                res.send(`Odjel s ID-em ${dept_no} uspješno ažuriran.`)
            } else 
            {
                console.log(err)
            }
        })
    })
})



app.listen(port, () => console.log(`Listening on port ${port}`))