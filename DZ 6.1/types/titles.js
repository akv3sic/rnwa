const { GraphQLObjectType, GraphQLInt, GraphQLString, GraphQLList } = require('graphql');
const { dbQuery } = require('../database');
const employeesType = require('./employees');

const titlesType = new GraphQLObjectType({
  name: 'titles',
  fields:() => (
    {
      emp_no: { type: GraphQLInt },
      title: { type: GraphQLString },
      from_date:{ type: GraphQLString },
      to_date:{ type: GraphQLString },
      employee: { 
        type: employeesType,
        resolve: async (post) => {
          let res = await dbQuery(`SELECT * FROM employees WHERE emp_no = ${parseInt(post.emp_no)}`);
          return res[0];
        }
      }
    }
  ) 
});

module.exports = titlesType;