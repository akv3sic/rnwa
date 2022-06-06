const { GraphQLObjectType, GraphQLInt, GraphQLString, GraphQLList } = require('graphql');

const employeesType = new GraphQLObjectType({
  name: 'employees',
  fields: {
    emp_no: { type: GraphQLInt },
    first_name: { type: GraphQLString },
    last_name: { type: GraphQLString },
    gender: { type: GraphQLString },
    birth_date:{ type: GraphQLString },
    hire_date:{ type: GraphQLString }

  }
});

module.exports = employeesType;