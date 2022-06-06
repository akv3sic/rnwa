const { GraphQLObjectType } = require('graphql');
const inserttitles = require('./inserttitles');
const insertUser = require('./insertUser');
const updateemployees = require('./updateemployees');

const Mutation = new GraphQLObjectType({
  name: 'mutation',
  fields: {
    // Insert a new user record
    insertUser: insertUser,
    updateemployees: updateemployees,
    inserttitles:inserttitles,
  }
});

module.exports = Mutation;
