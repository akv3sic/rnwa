const { GraphQLString, GraphQLInt } = require('graphql');
const { dbQuery } = require('../../database');
const { employeesType } = require('../../types');

const updateemployees = {
  type: employeesType,
  args: {
    emp_no :{ type: GraphQLInt },
    first_name: { type: GraphQLString },
    last_name: { type: GraphQLString }
  },
  async resolve(_, {emp_no, first_name, last_name }){
    let res = await dbQuery(`update employees set first_name= "${first_name}", last_name= "${last_name}"  where emp_no = ${emp_no};`);
    return { emp_no, first_name, last_name }
  }
};

module.exports = updateemployees;