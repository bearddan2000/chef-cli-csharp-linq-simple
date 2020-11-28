FROM ubuntu:20.04

WORKDIR /usr/local
ARG IN_FILE="Program.cs"
ARG OUT_FILE="Program.exe"

COPY bin/ .

RUN apt-get update \
    && DEBIAN_FRONTEND=noninteractive apt-get install -y chef git \
    && git clone https://github.com/bearddan2000/chef-lib-recipes.git \
    && chmod -R +x chef-lib-recipes \
    && mkdir -p cookbooks/op/recipes \
    && mv chef-lib-recipes/lang/mono.rb cookbooks/op/recipes/default.rb \
    && chef-solo -c chef-lib-recipes/solo.rb -o 'recipe[op]'

RUN chmod +x ${IN_FILE} \
    && mcs -o:${OUT_FILE} ${IN_FILE} \
    && chmod +x ${OUT_FILE}

CMD ["mono", "Program.exe"]
