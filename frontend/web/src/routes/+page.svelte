<script lang="ts">
	import { onMount } from 'svelte';
	import { api } from '../api/api';
	import type { Sample, User } from '../api/client';
	import { each } from 'svelte/internal';

	let samples: Sample[] = [];

	async function refresh() {
		let res = await api.sample.getAllSample();
		samples = res.data;
	}

	async function create() {
		let res2 = await api.alessia.getAlessia('');
		let res = await api.sample.createSample({
			name: 'Kick01',
			description: 'A simple kick',
			tag: ['kick']
		});
		await refresh();
		console.log(res);
	}

	async function addTag() {
		let id = samples[0].id!;
		let res = await api.sample.addTag({ tag: 'sample', id: id });
		await refresh();
	}

	onMount(async () => {
		refresh();
	});
</script>

<div on:click={() => create()} class="border">create</div>
<div on:click={() => addTag()} class="border">add</div>

<div class="flex flex-col">
	{#each samples as sample}
		{sample.tag}
	{/each}
</div>
