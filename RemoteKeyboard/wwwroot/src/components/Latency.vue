<script setup lang="ts">
import {ref} from "vue";


const props = defineProps({uri: String})

const ws_latency = new WebSocket(`${props.uri}/latency`);

ws_latency.onmessage = function (event) {
    let js = JSON.parse(event.data);

    if (js.type === 'rep1') {
        ws_latency.send(JSON.stringify({
            'type': 'ask2',
            'time_client': js.time_client,
            'time_server': js.time_server,
            'time_client_2': Date.now().toString()
        }))
    }

    if (js.type === 'rep2') {
        let time_client   = parseInt(js.time_client)
        let time_server   = parseInt(js.time_server)
        let time_client_2 = parseInt(js.time_client_2)
        let time_server_2 = parseInt(js.time_server_2)

        latency.value = (time_client_2 - time_client + time_server_2 - time_server) / 4
    }
};

function test_latency() {
    ws_latency.send(JSON.stringify({
        'type': 'ask1',
        'time_client': Date.now().toString()
    }))
}

let latency = ref(-1)
</script>

<template>
    <button @click="test_latency">test latency</button>
    latency: {{ latency }}ms
</template>