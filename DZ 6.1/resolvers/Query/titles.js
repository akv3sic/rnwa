const { GraphQLList } = require('graphql');
const { dbQuery } = require('../../database');
const { titlesType } = require('../../types');

const fieldstitles = {
  type: new GraphQLList(titlesType),
  async resolve(_, {}){
    let res = await dbQuery(`SELECT * FROM titles limit 100`);

    return res;
  }
};

module.exports = fieldstitles;