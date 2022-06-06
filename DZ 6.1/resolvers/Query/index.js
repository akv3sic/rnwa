const { GraphQLObjectType } = require('graphql');

const fieldsUser = require('./user');
const fieldsUsers = require('./users');
const fieldsPosts = require('./posts');
const fieldsemployees = require('./employees');
const fieldstitles = require('./titles');

const Query = new GraphQLObjectType({
  name: 'Query',
  fields: {
    // Query one user
    user: fieldsUser,
    // Query all users
    users: fieldsUsers,
    // Query all posts
    posts: fieldsPosts,

    employees : fieldsemployees,
    titles : fieldstitles,
  }
});

module.exports = Query;