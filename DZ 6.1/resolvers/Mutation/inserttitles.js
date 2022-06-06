const { GraphQLString, GraphQLInt } = require('graphql');
const { dbQuery } = require('../../database');
const { titlesType } = require('../../types');

const inserttitles = {
  type: titlesType,
  args: {
    emp_no: { type: GraphQLInt },
    title: { type: GraphQLString }
  },
  async resolve(_, { emp_no, title }){
    let res = await dbQuery(`insert into titles (emp_no, title) values (${emp_no}, '${title}');`);
    return {  emp_no, title }
  }
};

module.exports = inserttitles;